using ReactiveUI;
using System;
using System.Reactive;
using System.Threading.Tasks;
using UWPReactiveUI.Services.Impl;
using UWPReactiveUI.Services.Interfaces;
using UWPReactiveUI.Services.Models;

namespace UWPReactiveUI.Core
{
    public class HipsterViewModel : ReactiveObject
    {
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

        public HipsterViewModel()
        {
            ExecuteGetSentence = ReactiveCommand.CreateFromTask(GetSentenceAsync);

            _isLoading = ExecuteGetSentence.IsExecuting.ToProperty(this, x => x.IsLoading, true);

            _sentence = ExecuteGetSentence.ToProperty(this, x => x.Sentence, new HipsterSentence { Text = "Hipster Eggs !" });
        }

        public async Task<HipsterSentence> GetSentenceAsync()
        {
            // We should use an IoC
            IHipsterService hipsterService = new HipsterService();

            // To be able to see the effects (for the demo)
            await Task.Delay(TimeSpan.FromSeconds(3));

            return await hipsterService.GetSentenceAsync();
        }
    }
}
