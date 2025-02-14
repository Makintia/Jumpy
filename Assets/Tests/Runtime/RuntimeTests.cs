using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Jumpy;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Profiling.Experimental;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class TestScripts
{
	// [UnitySetUp] -  �����,� ������� ������ ����������� ��� ������ ����
	// ���������� �������� ( IEnumerator) ��� ���������� �����������
	// ���������� � SceneManager - ������������� ������ �������� ����
	// ����������� ��� ������� ����� - �������� ����� "Game"
	//
	//
	// 'yield return null'  - ���������� ��� �����, ����� ��������� �������� �����

	[UnitySetUp]
	public IEnumerator Setup()
	{
		SceneManager.LoadScene("Game");
		yield return null;
		yield return null;
	}

	// [TearDown] - �����,� ������� ������ �����������. �� ���� ��, ��� ����� ����������� ����� ������
	// ��� ����� ������, ��� ��� �� �� ���������� ����-������� � ���� ������
	// ����� ������� �� ������ �� ����������� � ������� �� ��������������� ������, ������� �������� � ���������
	[TearDown]
	public void Teardown()
	{
	}
	/*
[UnityTest] - ��� ����. ������� �������� ��� ���� �������� �� ������ Start

1) ��� ���� - �� ��������� ��� ���� �������� �� ������ Start
2) ������ ��������� �������� ������� � 20 ���, ����� ���� ��� �������
3) ����� ������� ��������� ������
4) ������� ����������� (Assert), ��� ��������� ������ �� ������
5) �������� ������ ������� ���������� startButton ��������� ���� ������ PlayButton
6) ������ ����������� (Assert), ��� ������ ��������� �� ������ (�� ����� ���������� ������ (null))
7) �������� �� ������ startButton
8) ����� ���������� time � ����� float � ������ ���� while (����� �� ������ ������� ������� ���������� ���� �������� 5 ���)

Time.DeltaTime ����������� ����� �����, �������� � ��� ����� ���: https://docs.unity3d.com/Manual/TimeFrameManagement.html 
	*/
	[UnityTest]
	public IEnumerator CheckGameStartOnStartButton()
	{
		Time.timeScale = 20.0f;
		var titleScreen = Object.FindObjectOfType<TitleScreenPopup>();
		{
			Assert.IsNotNull(titleScreen);
		}

		var startButton = GameObject.Find("PlayButton");
		{
			Assert.IsNotNull(startButton);
		}

		titleScreen.PerformClickActionsPopup(startButton);
		var time = 0f;
		while (time < 5f)      // ����                      			   
		{
			time += Time.fixedDeltaTime;
			yield return new WaitForFixedUpdate();
		}

		/*
9) ����� ���� ��� ������� ������ �� ����� ������������� ����� ������� ������� �������(����������)
10) ������� �� ����� ������ InGameInterface - ��� ��� ��� ����� ����� ����
11) ����� ����� �����������(Assert), ��� ������� ��������� ���������� � �� ������� 

��������� ����� �������� � ���
		*/
		Time.timeScale = 1f;
		var inGameInterface = Object.FindObjectOfType<InGameInterface>(true);
		{
			Assert.IsNotNull(inGameInterface);
			Assert.IsTrue(inGameInterface.gameObject.activeSelf);
		}
		Debug.Log(inGameInterface + (" loaded sucsess"));
	}
}