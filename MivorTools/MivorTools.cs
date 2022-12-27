// MivorTools
// a Valheim mod skeleton using Jötunn
// 
// File:    MivorTools.cs
// Project: MivorTools

using BepInEx;
using BepInEx.Configuration;
using Jotunn.Entities;
using Jotunn.Managers;

// Jotunn's features: https://valheim-modding.github.io/Jotunn/tutorials/overview.html

namespace MivorTools
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    //[NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    internal class MivorTools : BaseUnityPlugin
    {
        public const string PluginGUID = "net.mivor.dev.valheim.mivortools";
        public const string PluginName = "MivorTools";
        public const string PluginVersion = "0.0.1";
        
        // Use this class to add your own localization to the game
        // https://valheim-modding.github.io/Jotunn/tutorials/localization.html
        public static CustomLocalization Localization = LocalizationManager.Instance.GetLocalization();

		private static ConfigEntry<bool> modIsEnabled;
		private static ConfigEntry<bool> debugLogging;
		private static ConfigEntry<string> featModifierKey;
		private static ConfigEntry<string> featMainKey;

		private void Awake()
        {

			modIsEnabled = Config.Bind<bool>("General", "Enabled", true, "Enable mod");
			debugLogging = Config.Bind<bool>("General", "Debug Logging", true, "Enable debug logging");

			featModifierKey = Config.Bind<string>("Features", "ModifierKey", "LeftControl", "Modifier Key to use mod features");
			featMainKey = Config.Bind<string>("Features", "MainKey", "E", "Main Key to use mod features");


			if (!modIsEnabled.Value) return;


			// Jotunn comes with its own Logger class to provide a consistent Log style for all mods using it
			if (debugLogging.Value) Jotunn.Logger.LogInfo("MivorTools mod has loaded");
            
        }
    }
}

