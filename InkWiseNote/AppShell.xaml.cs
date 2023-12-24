﻿using InkWiseNote.Pages;

namespace InkWiseNote;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(nameof(NoteTakingPage), typeof(NoteTakingPage));
    }
}
