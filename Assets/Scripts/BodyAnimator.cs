using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.U2D.Animation;

public class BodyAnimator : MonoBehaviour
{
    [SerializeField] private BodyPartType _bodyPartType;

    private SpriteLibrary _spriteLibrary;

    private SpriteResolver _spriteResolver;

    private Animator _animator;

    public BodyPartType BodyPartType => _bodyPartType;

    private bool animationPlaying => _animator.enabled;


    private void Awake()
    {
        _spriteLibrary = GetComponent<SpriteLibrary>();
        _spriteResolver = GetComponent<SpriteResolver>();
        _animator = GetComponent<Animator>();

        Assert.IsNotNull(_spriteLibrary, "BodyAnimator :: SpriteLibrary component is missing!");
        Assert.IsNotNull(_spriteResolver, "BodyAnimator :: SpriteResolver component is missing!");
        Assert.IsNotNull(_spriteResolver, "BodyAnimator :: Animator component is missing!");
    }

    public void ApplyNewAssetPack(SpriteLibraryAsset newAssetPack)
    {
        _spriteLibrary.spriteLibraryAsset = newAssetPack;
    }

    public void SetAnimationCategory(string newCategory)
    {
        if (newCategory == _spriteResolver.GetCategory())
            return;

        if (!animationPlaying)
            PlayAnimation();

        _spriteResolver.SetCategoryAndLabel(newCategory, _spriteResolver.GetLabel());
    }

    public void StopAnimation()
    {
        _animator.enabled = false;
        _spriteResolver.SetCategoryAndLabel(_spriteResolver.GetCategory(), _spriteResolver.GetLabel());
    }

    public void PlayAnimation()
    {
        _animator.enabled = true;
    }

}
