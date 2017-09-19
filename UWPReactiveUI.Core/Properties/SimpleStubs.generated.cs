using  System;
using  System.Runtime.CompilerServices;
using  Etg.SimpleStubs;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPReactiveUI.Services.Models;

namespace UWPReactiveUI.Services.Interfaces
{
    [CompilerGenerated]
    public class StubIHipsterService : IHipsterService
    {
        private readonly StubContainer<StubIHipsterService> _stubs = new StubContainer<StubIHipsterService>();

        public MockBehavior MockBehavior { get; set; }

        global::System.Threading.Tasks.Task<global::UWPReactiveUI.Services.Models.HipsterSentence> global::UWPReactiveUI.Services.Interfaces.IHipsterService.GetSentenceAsync(int paragraphs, global::UWPReactiveUI.Services.Models.HipsterType type, bool useHtml)
        {
            GetSentenceAsync_Int32_HipsterTypeHipsterTypeLatin_Boolean_Delegate del;
            if (MockBehavior == MockBehavior.Strict)
            {
                del = _stubs.GetMethodStub<GetSentenceAsync_Int32_HipsterTypeHipsterTypeLatin_Boolean_Delegate>("GetSentenceAsync");
            }
            else
            {
                if (!_stubs.TryGetMethodStub<GetSentenceAsync_Int32_HipsterTypeHipsterTypeLatin_Boolean_Delegate>("GetSentenceAsync", out del))
                {
                    return Task.FromResult(default(global::UWPReactiveUI.Services.Models.HipsterSentence));
                }
            }

            return del.Invoke(paragraphs, type, useHtml);
        }

        public delegate global::System.Threading.Tasks.Task<global::UWPReactiveUI.Services.Models.HipsterSentence> GetSentenceAsync_Int32_HipsterTypeHipsterTypeLatin_Boolean_Delegate(int paragraphs, global::UWPReactiveUI.Services.Models.HipsterType type, bool useHtml);

        public StubIHipsterService GetSentenceAsync(GetSentenceAsync_Int32_HipsterTypeHipsterTypeLatin_Boolean_Delegate del, int count = Times.Forever, bool overwrite = false)
        {
            _stubs.SetMethodStub(del, count, overwrite);
            return this;
        }

        public StubIHipsterService(MockBehavior mockBehavior = MockBehavior.Loose)
        {
            MockBehavior = mockBehavior;
        }
    }
}