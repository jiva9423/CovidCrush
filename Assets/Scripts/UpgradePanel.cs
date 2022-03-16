using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanel : MonoBehaviour
{
    private Animator upgradeAnimator;
    public Image openArrowButton;
    public Image closeArrowButton;


    private void Start()
    {
        upgradeAnimator = GetComponent<Animator>();
    }


    public void CloseUpgradePanel() {
        StoreData.upgradePanelIsOpen = false;
        StartCoroutine(PlayCloseAnimation());
    }

    public void OpenUpgradePanel() {
        StoreData.upgradePanelIsOpen = true;
        StartCoroutine(PlayOpenAnimation());
    }

    IEnumerator PlayOpenAnimation()
    {
        //waits till animation is done to play.
        upgradeAnimator.Play("UpgradeMenuOpen");
        closeArrowButton.enabled = false;
        yield return new WaitForSeconds(.4f);
        openArrowButton.enabled = true;
        upgradeAnimator.Play("UpgradeMenuOpened");
    }

    IEnumerator PlayCloseAnimation()
    {
        //waits till animation is done to play.
        upgradeAnimator.Play("UpgradeMenuClose");
        openArrowButton.enabled = false;
        
        yield return new WaitForSeconds(.4f);
        closeArrowButton.enabled = true;
        upgradeAnimator.Play("UpgradeMenuClosed");
    }
}
