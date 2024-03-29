﻿using System.Collections.ObjectModel;

using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;

using InkWiseCore.UiComponents.UiLayouts;

namespace InkWiseCore.UiComponents.UiElements;

public interface IHaveDrawingViewData
{
    ObservableCollection<IDrawingLine> Lines { get; }
    Color LineColor { get; }

    Color BackgroundColor { get; }
    int LineWidth { get; }
}


public class DrawingViewElement : IUiElement
{
    public View UiView { get; private set; }

    public DrawingView DrawingView => (DrawingView) UiView;

    public DrawingViewElement()
    {
        UiView = new DrawingView
        {
            IsMultiLineModeEnabled = true,
            ShouldClearOnFinish = false
        };

        UiView.SetBinding(DrawingView.LinesProperty, nameof(IHaveDrawingViewData.Lines));
        UiView.SetBinding(DrawingView.LineColorProperty, nameof(IHaveDrawingViewData.LineColor));
        UiView.SetBinding(DrawingView.BackgroundColorProperty, nameof(IHaveDrawingViewData.BackgroundColor));
        UiView.SetBinding(DrawingView.LineWidthProperty, nameof(IHaveDrawingViewData.LineWidth));
    }
}
