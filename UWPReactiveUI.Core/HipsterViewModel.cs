using ReactiveUI;
using System;
using System.Reactive;
using System.Threading.Tasks;
using UWPReactiveUI.Services.Interfaces;
using UWPReactiveUI.Services.Models;

namespace UWPReactiveUI.Core
{
    public class HipsterViewModel : ReactiveObject
    {
        private readonly IHipsterService _hipsterService;

        private ObservableAsPropertyHelper<HipsterSentence> _sentence;
        public HipsterSentence Sentence
        {
            get { return _sentence.Value; }
        }

        private ObservableAsPropertyHelper<bool> _isLoading;
        public bool IsLoading
        {
            get { return _isLoading.Value; }
        }

        public ReactiveCommand<Unit, HipsterSentence> ExecuteGetSentence { get; protected set; }

        public HipsterViewModel(IHipsterService hipsterService)
        {
            _hipsterService = hipsterService;
            ExecuteGetSentence = ReactiveCommand.CreateFromTask(GetSentenceAsync);

            _isLoading = ExecuteGetSentence.IsExecuting.ToProperty(this, x => x.IsLoading, true);

            _sentence = ExecuteGetSentence.ToProperty(this, x => x.Sentence, new HipsterSentence { Text = "Hipster Eggs !" });
        }

        public HipsterViewModel()
        {
            // For design-time purpose
        }

        private async Task<HipsterSentence> GetSentenceAsync()
        {
            return await _hipsterService.GetSentenceAsync();
        }
    }
}
