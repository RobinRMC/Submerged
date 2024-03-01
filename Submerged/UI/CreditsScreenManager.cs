using Reactor.Utilities.Attributes;
using Submerged.Localization.Strings;
using TMPro;
using UnityEngine;

namespace Submerged.UI;

[RegisterInIl2Cpp]
public sealed class CreditsScreenManager : MonoBehaviour
{
    private const string TRANSLATORS = "DekoKiyo (日本語), ItsNiceCraft (Deutsch), MissJukebox (Español),\n" +
                                       "Monid73 (Русский), RevoLou (Português do Brasil), RobinRMC (Nederlands),\n" +
                                       "SPRLC (Français), ねろちゃん (日本語), 阿龍DragonTw (繁體中文), 黑客Hecker (简体中文)";

    public CreditsScreenManager(IntPtr ptr) : base(ptr) { }

    public void Awake()
    {
        TMP_FontAsset font = FindObjectOfType<VersionShower>().text.font;

        foreach (TextMeshPro tmp in GetComponentsInChildren<TextMeshPro>())
        {
            tmp.font = font;
        }
    }

    public void OnEnable()
    {
        Transform textParent = transform.Find("Credits");
        textParent.Find("Project Lead").GetComponent<TextMeshPro>().text = General.Credits_ProjectLead;
        textParent.Find("Map Design").GetComponent<TextMeshPro>().text = General.Credits_MapDesign;
        textParent.Find("Developers").GetComponent<TextMeshPro>().text = General.Credits_Developers;
        textParent.Find("Artists").GetComponent<TextMeshPro>().text = General.Credits_Artists;
        textParent.Find("Technical Support").GetComponent<TextMeshPro>().text = General.Credits_TechnicalSupport;
        textParent.Find("Additional Art").GetComponent<TextMeshPro>().text = General.Credits_AdditionalArt;
        transform.Find("Translators/Text").GetComponent<TextMeshPro>().text = $"<u><b>{General.Credits_Translators}:</b></u> {TRANSLATORS}";

        TextMeshPro devText = textParent.Find("Developers/Subtext").GetComponent<TextMeshPro>();
        // TODO: Rebuild this asset
        devText.text = devText.text.Replace("AlexejheroYTB", "Alexejhero").Replace("associatedlogos", "probablyadnf");
    }
}
