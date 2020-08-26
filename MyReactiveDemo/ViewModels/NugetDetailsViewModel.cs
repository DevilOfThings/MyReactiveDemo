using System;
using System.Diagnostics;
using System.Reactive;
using NuGet.Protocol.Core.Types;
using ReactiveUI;

namespace MyReactiveDemo.ViewModels
{
    public class NugetDetailsViewModel : ReactiveObject
    {
        private readonly IPackageSearchMetadata _metaData;
        private readonly Uri _defaultUrl;

        public NugetDetailsViewModel(IPackageSearchMetadata metaData)
        {
            _metaData = metaData;
            _defaultUrl = new Uri("http://git.io/fAlfh");

            OpenPage = ReactiveCommand.Create(() =>
            {
                Process.Start(new ProcessStartInfo(
                    this.ProjectUrl.ToString())
                {
                    UseShellExecute = true
                });
            });
        }

        public Uri IconUrl => _metaData.IconUrl ?? _defaultUrl;
        public string Description => _metaData.Description;
        public Uri ProjectUrl => _metaData.ProjectUrl;
        public string Title => _metaData.Title;

        public ReactiveCommand<Unit, Unit> OpenPage { get; }
    }
}