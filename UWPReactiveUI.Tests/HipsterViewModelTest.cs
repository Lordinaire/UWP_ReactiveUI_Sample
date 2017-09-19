using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReactiveUI;
using UWPReactiveUI.Core;
using UWPReactiveUI.Services.Interfaces;
using UWPReactiveUI.Services.Models;

namespace UWPReactiveUI.Tests
{
    [TestClass]
    public class HipsterViewModelTest
    {
        [TestMethod]
        public async Task Should_return_a_sentence_When_request_one()
        {
            // Given
            var stub = new StubIHipsterService();
            var sentence = new HipsterSentence
            {
                Text = "Toto"
            };
            stub.GetSentenceAsync(async (paragraphs, type, html) => sentence);
            var viewModel = new HipsterViewModel(stub);

            // When
            await viewModel.ExecuteGetSentence.Execute(Unit.Default);

            // Then
            Assert.AreEqual(sentence, viewModel.Sentence);
        }

        [TestMethod]
        public async Task Should_loading_When_request_a_sentence()
        {
            // Given
            var stub = new StubIHipsterService();
            stub.GetSentenceAsync(async (paragraphs, type, html) => null);
            var viewModel = new HipsterViewModel(stub);

            var hasChanged = false;
            viewModel.WhenAny(x => x.IsLoading, isLoading => isLoading)
                     .Subscribe(x =>
                        {
                            if (x.Value)
                                hasChanged = true;
                        });

            // When
            await viewModel.ExecuteGetSentence.Execute(Unit.Default);

            // Then
            Assert.IsTrue(hasChanged);
        }
    }
}
