using UnityEngine;
using Zenject;

namespace Core.Gallery
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Gallery Settings")]
    public class SettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private GallerySettings _settings;

        public override void InstallBindings()
        {
            Container.BindInstance<GallerySettings>(_settings).AsSingle();
        }
    }
}
