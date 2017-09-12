using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helper.CodeFormatter
{
    public abstract partial class CLikeFormat : CodeFormat
    {
        /// <summary>
        /// Regular expression string to match single line and multi-line 
        /// comments (// and /* */). 
        /// </summary>
        protected override string CommentRegex
        {
            get { return @"/\*.*?\*/|//.*?(?=\r|\n)"; }
        }

        /// <summary>
        /// Regular expression string to match string and character literals. 
        /// </summary>
        protected override string StringRegex
        {
            get { return @"@?""""|@?"".*?(?!\\).""|''|'.*?(?!\\).'"; }
        }
    }
}
