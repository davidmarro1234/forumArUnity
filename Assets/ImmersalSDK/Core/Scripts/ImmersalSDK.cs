/*===============================================================================
Copyright (C) 2020 Immersal Ltd. All Rights Reserved.

This file is part of the Immersal SDK.

The Immersal SDK cannot be copied, distributed, or made available to
third-parties for commercial purposes without written permission of Immersal Ltd.

Contact sdk@immersal.com for licensing requests.
===============================================================================*/

using UnityEngine;
using Unity.Collections;
using UnityEngine.XR.ARFoundation;
using System;

namespace Immersal
{
	public class ImmersalSDK : MonoBehaviour
	{
		public static string sdkVersion = "1.5.0";
		public static bool isHWAR = false;

        public enum CameraResolution { Default, HD, FullHD, Max };	// With Huawei AR Engine SDK, only Default (640x480) and Max (1440x1080) are supported.
		private static ImmersalSDK instance = null;

		[Tooltip("SDK developer token")]
		public string developerToken;
		[SerializeField]
		[Tooltip("Application target frame rate")]
		private int m_TargetFrameRate = 60;
		[SerializeField]
		[Tooltip("Android resolution")]
		private CameraResolution m_AndroidResolution = CameraResolution.FullHD;
		[SerializeField]
		[Tooltip("iOS resolution")]
		private CameraResolution m_iOSResolution = CameraResolution.Default;
		private ARCameraManager m_CameraManager;
		private ARSession m_ARSession;
        private bool m_bCamConfigDone = false;
		private string m_LocalizationServer = "https://dev01.immersal.com";

		public int targetFrameRate
		{
			get { return m_TargetFrameRate; }
			set
			{
				m_TargetFrameRate = value;
				SetFrameRate();
			}
		}

		public CameraResolution androidResolution
		{
			get { return m_AndroidResolution; }
		}

		public CameraResolution iOSResolution
		{
			get { return m_iOSResolution; }
		}

		public string localizationServer
		{
			get { return m_LocalizationServer; }
		}

		public ARCameraManager cameraManager
		{
			get
			{
				if (m_CameraManager == null)
				{
					m_CameraManager = UnityEngine.Object.FindObjectOfType<ARCameraManager>();
					//if (m_CameraManager == null)
					//	Debug.Log("No ARCameraManager found");
				}
				return m_CameraManager;
			}
		}

		public ARSession arSession
		{
			get
			{
				if (m_ARSession == null)
				{
					m_ARSession = UnityEngine.Object.FindObjectOfType<ARSession>();
					if (m_ARSession == null)
						Debug.Log("No ARSession found");
				}
				return m_ARSession;
			}
		}

		public static ImmersalSDK Instance
		{
			get
			{
#if UNITY_EDITOR
				if (instance == null && !Application.isPlaying)
				{
					instance = UnityEngine.Object.FindObjectOfType<ImmersalSDK>();
				}
#endif
				if (instance == null)
				{
					Debug.LogError("No ImmersalSDK instance found. Ensure one exists in the scene.");
				}
				return instance;
			}
		}

		void Awake()
		{
			if (instance == null)
			{
				instance = this;
			}
			if (instance != this)
			{
				Debug.LogError("There must be only one ImmersalSDK object in a scene.");
				UnityEngine.Object.DestroyImmediate(this);
				return;
			}

			if (developerToken != null && developerToken.Length > 0)
			{
				PlayerPrefs.SetString("token", developerToken);
			}
		}

		void Start()
		{
			SetFrameRate();
		}

		private void SetFrameRate()
		{
			Application.targetFrameRate = targetFrameRate;
		}

		private void Update()
		{
			if (isHWAR) return;
			
			if (!m_bCamConfigDone && cameraManager != null)
				ConfigureCamera();
		}

		private void ConfigureCamera()
		{
#if !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS)
			var cameraSubsystem = cameraManager.subsystem;
			if (cameraSubsystem == null || !cameraSubsystem.running)
				return;
			var configurations = cameraSubsystem.GetConfigurations(Allocator.Temp);
			if (!configurations.IsCreated || (configurations.Length <= 0))
				return;
			int bestError = int.MaxValue;
			var currentConfig = cameraSubsystem.currentConfiguration;
			int dw = (int)currentConfig?.width;
			int dh = (int)currentConfig?.height;
			if (dw == 0 && dh == 0)
				return;
#if UNITY_ANDROID
			CameraResolution reso = androidResolution;
#else
			CameraResolution reso = iOSResolution;
#endif
			switch (reso)
			{
				case CameraResolution.Default:
					dw = (int)currentConfig?.width;
					dh = (int)currentConfig?.height;
					break;
				case CameraResolution.HD:
					dw = 1280;
					dh = 720;
					break;
				case CameraResolution.FullHD:
					dw = 1920;
					dh = 1080;
					break;
				case CameraResolution.Max:
					dw = 80000;
					dh = 80000;
					break;
			}

			foreach (var config in configurations)
			{
				int perror = config.width * config.height - dw * dh;
				if (Math.Abs(perror) < bestError)
				{
					bestError = Math.Abs(perror);
					currentConfig = config;
				}
			}

			if (reso != CameraResolution.Default) {
				Debug.Log("resolution = " + (int)currentConfig?.width + "x" + (int)currentConfig?.height);
				cameraSubsystem.currentConfiguration = currentConfig;
			}
#endif
			m_bCamConfigDone = true;
		}
	}
}