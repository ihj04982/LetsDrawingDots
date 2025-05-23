﻿using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using Epoching_Sober;

public static class PostProcessBuild
{
    [PostProcessBuild]
    public static void OnPostprocessBuild(BuildTarget target, string projpath)
    {
        if (target != BuildTarget.iOS) 
        {
            Debug.LogWarning("Current BuildTarget is Not Ios!");
            return;
        }

        string fullPath = Path.GetFullPath(projpath);
        EidtInfoPlist(fullPath);
    }

    private static void EidtInfoPlist(string projpath)
    {
        XCPlist plist = new XCPlist(projpath);

        string PlistAdd = @"  
            <key>CFBundleURLTypes</key>
			<array>
				<dict>
					<key>CFBundleURLName</key>
					<string>meipai</string>
					<key>CFBundleURLSchemes</key>
					<array>
						<string>mp1089867596</string>
					</array>
				</dict>
				<dict>
					<key>CFBundleURLSchemes</key>
					<array>
						<string>dingoanxyrpiscaovl4qlw</string>
					</array>
					<key>CFBundleURLName</key>
					<string>dingtalk</string>
				</dict>
				<dict>
					<key>CFBundleURLSchemes</key>
					<array>
						<string>ap2015072400185895</string>
					</array>
					<key>CFBundleURLName</key>
					<string>alipayShare</string>
				</dict>
				<dict>
					<key>CFBundleURLSchemes</key>
					<array>
					<string>vk5312801</string>
					<string>yx0d9a9f9088ea44d78680f3274da1765f</string>
					<string>pin4797078908495202393</string>
					<string>kakao48d3f524e4a636b08d81b3ceb50f1003</string>
					<string>pdk4797078908495202393</string>
					<string>tb2QUXqO9fcgGdtGG1FcvML6ZunIQzAEL8xY6hIaxdJnDti2DYwM</string>
					<string>com.mob.demoShareSDK</string>
					<string>rm226427com.mob.demoShareSDK</string>
					<string>pocketapp1234</string>
					<string>QQ05FB8B52</string>
					<string>wx4868b35061f87885</string>
					<string>tencent100371282</string>
					<string>fb107704292745179</string>
					<string>wb568898243</string>
					</array>
				</dict>
			</array>
                   <key>NSPhotoLibraryAddUsageDescription</key>
                   <string>Screenshot needs to access the photo library</string>";

        //白名单添加，需要白名单才可以打开地址
        string LSAdd = @"
		<key>LSApplicationQueriesSchemes</key>
			<array>
			<string>dingtalk-open</string>
			<string>dingtalk</string>
			<string>mqqopensdkapiV4</string>
			<string>weibosdk</string>
			<string>sinaweibohd</string>
			<string>sinaweibo</string>
			<string>vkauthorize</string>
			<string>fb-messenger</string>
			<string>yixinfav</string>
			<string>yixinoauth</string>
			<string>yixinopenapi</string>
			<string>yixin</string>
			<string>pinit</string>
			<string>kakaolink</string>
			<string>kakao48d3f524e4a636b08d81b3ceb50f1003</string>
			<string>alipay</string>
			<string>storykompassauth</string>
			<string>pinterestsdk.v1</string>
			<string>kakaokompassauth</string>
			<string>alipayshare</string>
			<string>pinit</string>
			<string>line</string>
			<string>whatsapp</string>
			<string>mqqwpa</string>
			<string>instagram</string>
			<string>fbauth2</string>
			<string>renren</string>
			<string>renrenios</string>
			<string>renrenapi</string>
			<string>rm226427com.mob.demoShareSDK</string>
			<string>mqq</string>
			<string>mqqopensdkapiV2</string>
			<string>mqqopensdkapiV3</string>
			<string>wtloginmqq2</string>
			<string>mqqapi</string>
			<string>mqqOpensdkSSoLogin</string>
			<string>sinaweibohdsso</string>
			<string>sinaweibosso</string>
			<string>wechat</string>
			<string>weixin</string>
		</array>";

        plist.AddKey(PlistAdd);
        plist.AddKey(LSAdd);

        plist.Save();
    }
}
