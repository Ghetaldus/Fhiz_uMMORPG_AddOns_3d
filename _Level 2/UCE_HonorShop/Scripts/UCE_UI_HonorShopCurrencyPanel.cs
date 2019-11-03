// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using UnityEngine;

// UCE UI HONOR SHOP - CURRENCY PANEL

public partial class UCE_UI_HonorShopCurrencyPanel : MonoBehaviour
{
    public GameObject currencySlotPrefab;
    public Transform currencyContent;

    // -----------------------------------------------------------------------------------
    // Update
    // -----------------------------------------------------------------------------------
    private void Update()
    {
        Player player = Player.localPlayer;
        if (!player) return;

        if (gameObject.activeSelf)
        {
            // instantiate/destroy enough category slots
            UIUtils.BalancePrefabs(currencySlotPrefab.gameObject, player.UCE_currencies.Count, currencyContent);

            // -- Currencies
            for (int i = 0; i < player.UCE_currencies.Count; ++i)
            {
                UCE_UI_HonorCurrencySlot slot = currencyContent.GetChild(i).GetComponent<UCE_UI_HonorCurrencySlot>();
                slot.currencyImage.sprite = player.UCE_currencies[i].honorCurrency.image;
                slot.nameText.text = player.UCE_currencies[i].honorCurrency.name;
                slot.valueText.text = player.UCE_currencies[i].amount.ToString();
            }
        }
    }

    // -----------------------------------------------------------------------------------
}