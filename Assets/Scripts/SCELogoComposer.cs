using System;
using UnityEngine;
using DG.Tweening;

public class SCELogoComposer : MonoBehaviour
{
    public GameObject PolygonPrefab;
    public TextMesh[] Texts;

    private GameObject _subChildRight;
    private GameObject _subChildLeft;

    private void Start()
    {
        if (PolygonPrefab == null)
            throw new Exception("You must provide a PolygonPrefab");

        PrepareTexts();
        Camera.main.DOColor(Color.black, 2f).From().OnComplete(SetupArmature);
    }

    private void PrepareTexts()
    {
        foreach (var textMesh in Texts)
        {
            var startColor = textMesh.color;
            startColor.a = 0f;
            textMesh.color = startColor;
        }
    }

    private void SetupArmature()
    {
        //Create left and right fan
        var childRight = GameObject.Instantiate(PolygonPrefab, this.transform);
        childRight.name = "RightFragment";
        var childLeft = GameObject.Instantiate(PolygonPrefab, this.transform);
        childLeft.name = "LeftFragment";
        FlipHorizontalScale(childLeft);

        //Create right subfragment
        _subChildRight = GameObject.Instantiate(PolygonPrefab, this.transform);
        _subChildRight.name = "SubRightFragment";
        var subChildRightTransform = _subChildRight.transform.position;
        subChildRightTransform.z = subChildRightTransform.z - 0.01f;
        _subChildRight.transform.position = subChildRightTransform;

        //Create left subfragment
        _subChildLeft = GameObject.Instantiate(PolygonPrefab, this.transform);
        _subChildLeft.name = "SubLeftFragment";
        FlipHorizontalScale(_subChildLeft);
        FlipVerticalScale(_subChildLeft);
        var subChildLeftTransform = _subChildLeft.transform.localPosition;
        subChildLeftTransform.x = 0f;
        subChildLeftTransform.z = subChildLeftTransform.z - 0.01f;
        _subChildLeft.transform.position = subChildLeftTransform;

        //Animations
        _subChildRight.transform.DOScale(new Vector3(0.35f, 0.475f, 0.5f), 2f).SetEase(Ease.Linear);
        _subChildRight.transform.DOLocalMoveY(-0.45f, 1f);
        _subChildRight.transform.DOLocalMoveX(-0.025f, 1f);

        _subChildLeft.transform.DOScale(new Vector3(-0.35f, -0.475f, 0.5f), 2f).SetEase(Ease.Linear);
        _subChildLeft.transform.DOLocalMoveY(0.45f, 1f);
        _subChildLeft.transform.DOLocalMoveX(0.025f, 1f).OnComplete(() =>
        {
            foreach (var textMesh in Texts)
            {
                var targetColor = textMesh.color;
                targetColor.a = 1f;
                DOTween.To(() => textMesh.color, x => textMesh.color = x, targetColor, 1);
            }
        });
    }

    private void FlipHorizontalScale(GameObject target)
    {
        var flippedScale = target.transform.localScale;
        flippedScale.x = -flippedScale.x;

        target.transform.localScale = flippedScale;
    }

    private void FlipVerticalScale(GameObject target)
    {
        var flippedScale = target.transform.localScale;
        flippedScale.y = -flippedScale.y;

        var currentPos = target.transform.position;
        currentPos.y += 1f;
        target.transform.position = currentPos;

        target.transform.localScale = flippedScale;
    }
}
