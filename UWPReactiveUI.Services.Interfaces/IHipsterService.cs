using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPReactiveUI.Services.Models;

namespace UWPReactiveUI.Services.Interfaces
{
    /// <summary>
    /// http://hipsterjesus.com/
    /// parameters: 
    /// paras = [1 - 99] (default 4)
    /// type = ['hipster-latin', 'hipster-centric'] (default 'hipster-latin')
    /// html = ['false', 'true'] ( default 'true') - strips html from output, replaces p tags with newlines
    /// </summary>
    public interface IHipsterService
    {
        Task<HipsterSentence> GetSentenceAsync(int paragraphs = 4, HipsterType type = HipsterType.Latin, bool useHtml = true);
    }
}
