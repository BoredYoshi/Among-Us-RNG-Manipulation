using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Unity;
using UnityEngineInternal;

namespace AmongUsRNG
{
    public static class BuildInfo
    {
        public const string Name = "RNG_Manip";
        public const string Author = "BoredYoshi";
        public const string Company = null;
        public const string Version = "1.0.0";
        public const string DownloadLink = "N/A";
    }
    public class AmongUsRNG : MelonMod
    {
        private void CreateVisualObject()
        {
            GameObject visualObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            visualObject.transform.position = Camera.main.transform.position; // Adjust the position as needed
        }
        private static MelonPreferences_Entry<int> RNGSeed;
        private static int RNGSeedValue;

        public Rect Pos { get; private set; }

        public override void OnApplicationStart()
        {
            MelonLogger.Msg("We're in, boys.");
            RegisterPrefs();
            if(RNGSeed != null)
            {
                UnityEngine.Random.seed = RNGSeed.Value;
            }
        }
        public override void OnGUI()
        {
            base.OnGUI();
            
        }
        public void RegisterPrefs()
        {
            MelonPreferences_Category category = MelonPreferences.CreateCategory("RNGManip");
            RNGSeed = category.CreateEntry("RNGSeed", 1);
        }
        public override void OnUpdate()
        {
            if (Input.GetKey(KeyCode.F3) && Input.GetKeyDown(KeyCode.E))
            {
                MelonLogger.Msg("Manipulating...");
                if (RNGSeed != null)
                {
                    CreateVisualObject();
                    UnityEngine.Random.seed = RNGSeed.Value;
                }
            }
        }
    }
}