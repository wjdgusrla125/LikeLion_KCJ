using UnityEngine;
using System.Collections.Generic;

// 기본 카드 오브젝트 클래스
[CreateAssetMenu(fileName = "New CardObject", menuName = "Inventory System/Cards/CardObject")]
public class CardObject : ScriptableObject
{
    public Sprite uiDisplay;              // UI에 표시될 이미지
    public GameObject characterDisplay;   // 3D 모델
    public bool stackable;                // 중첩 가능 여부
    public CardType type;                 // 카드 타입
    public Card cardData = new Card();    // 기본 카드 데이터
    
    public List<string> boneNames = new List<string>(); // 본 이름 목록

    // 카드 인스턴스 생성 메서드
    public virtual Card CreateCard()
    {
        return new Card(this);
    }

    // Unity 에디터에서 값이 변경될 때 호출되는 메서드
    protected virtual void OnValidate()
    {
        boneNames.Clear();
        
        if (characterDisplay == null) return;
        
        if(!characterDisplay.GetComponent<SkinnedMeshRenderer>()) return;

        var renderer = characterDisplay.GetComponent<SkinnedMeshRenderer>();
        
        var bones = renderer.bones;

        // 본 이름 목록 업데이트
        foreach (var t in bones)
        {
            boneNames.Add(t.name);
        }
    }
}