﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Html;

namespace North.Shared
{
    partial class Footer
    {
        [Parameter]
        public string Content { get; set; } = string.Empty;

        [Parameter]
        public string Style { get; set; } = string.Empty;
    }
}
