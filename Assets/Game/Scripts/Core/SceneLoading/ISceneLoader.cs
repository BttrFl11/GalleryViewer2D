namespace Core.SceneLoading
{
    public interface ISceneLoader
    {
        void Load(int sceneIndex);
        void LoadImageView();
        void LoadGallery();
        void LoadMenu();
        void LoadNext();
        void LoadPrevious();
    }
}
