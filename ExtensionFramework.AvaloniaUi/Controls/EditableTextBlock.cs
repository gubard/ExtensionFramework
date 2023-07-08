using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace ExtensionFramework.AvaloniaUi.Controls;

[TemplatePart(TextBlockPartName, typeof(TextBlock))]
[TemplatePart(TextBoxPartName, typeof(TextBox))]
[TemplatePart(EditButtonPartName, typeof(Button))]
[TemplatePart(OkButtonPartName, typeof(Button))]
[TemplatePart(CancelButtonPartName, typeof(Button))]
public class EditableTextBlock : TemplatedControl
{
    public const string TextBlockPartName = "PART_TextBlock";
    public const string TextBoxPartName = "PART_TextBox";
    public const string EditButtonPartName = "PART_EditButton";
    public const string OkButtonPartName = "PART_OkButton";
    public const string CancelButtonPartName = "PART_CancelButton";

    /// <summary>
    /// Defines the <see cref="Text"/> property.
    /// </summary>
    public static readonly StyledProperty<string?> TextProperty = TextBlock.TextProperty.AddOwner<EditableTextBlock>();

    /// <summary>
    /// Defines the <see cref="AcceptsReturn"/> property
    /// </summary>
    public static readonly StyledProperty<bool> AcceptsReturnProperty =
        TextBox.AcceptsReturnProperty.AddOwner<EditableTextBlock>();

    /// <summary>
    /// Defines the <see cref="AcceptsTab"/> property
    /// </summary>
    public static readonly StyledProperty<bool> AcceptsTabProperty =
        TextBox.AcceptsTabProperty.AddOwner<EditableTextBlock>();

    public static readonly StyledProperty<TextWrapping> TextWrappingProperty =
        TextBlock.TextWrappingProperty.AddOwner<EditableTextBlock>();

    private TextBlock? textBlock;
    private TextBox? textBox;
    private Button? editButton;
    private Button? okButton;
    private Button? cancelButton;

    /// <summary>
    /// Gets or sets the text.
    /// </summary>
    public string? Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    /// <summary>
    /// Gets or sets a value that determines whether the TextBox allows and displays newline or return characters
    /// </summary>
    public bool AcceptsReturn
    {
        get => GetValue(AcceptsReturnProperty);
        set => SetValue(AcceptsReturnProperty, value);
    }

    /// <summary>
    /// Gets or sets a value that determins whether the TextBox allows and displays tabs
    /// </summary>
    public bool AcceptsTab
    {
        get => GetValue(AcceptsTabProperty);
        set => SetValue(AcceptsTabProperty, value);
    }

    /// <summary>
    /// Gets or sets the <see cref="Media.TextWrapping"/> of the TextBox
    /// </summary>
    public TextWrapping TextWrapping
    {
        get => GetValue(TextWrappingProperty);
        set => SetValue(TextWrappingProperty, value);
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        if (editButton is not null)
        {
            editButton.Click -= Edit;
        }

        if (okButton is not null)
        {
            okButton.Click -= Ok;
        }

        if (cancelButton is not null)
        {
            cancelButton.Click -= Cancel;
        }

        textBlock = e.NameScope.Get<TextBlock>(TextBlockPartName);
        textBox = e.NameScope.Get<TextBox>(TextBoxPartName);
        editButton = e.NameScope.Get<Button>(EditButtonPartName);
        okButton = e.NameScope.Get<Button>(OkButtonPartName);
        cancelButton = e.NameScope.Get<Button>(CancelButtonPartName);
        editButton.Click += Edit;
        okButton.Click += Ok;
        cancelButton.Click += Cancel;
    }

    private void Edit(object? sender, RoutedEventArgs e)
    {
        if (!IsInited())
        {
            return;
        }

        textBox.Text = textBlock.Text;
        textBlock.IsVisible = false;
        textBox.IsVisible = true;
        editButton.IsVisible = false;
        okButton.IsVisible = true;
        cancelButton.IsVisible = true;
    }

    private void Ok(object? sender, RoutedEventArgs e)
    {
        if (!IsInited())
        {
            return;
        }

        textBlock.Text = textBox.Text;
        textBlock.IsVisible = true;
        textBox.IsVisible = false;
        editButton.IsVisible = true;
        okButton.IsVisible = false;
        cancelButton.IsVisible = false;
    }

    private void Cancel(object? sender, RoutedEventArgs e)
    {
        if (!IsInited())
        {
            return;
        }

        textBlock.IsVisible = true;
        textBox.IsVisible = false;
        editButton.IsVisible = true;
        okButton.IsVisible = false;
        cancelButton.IsVisible = false;
    }

    private bool IsInited()
    {
        if (textBlock is null)
        {
            return false;
        }

        if (textBox is null)
        {
            return false;
        }

        if (editButton is null)
        {
            return false;
        }

        if (okButton is null)
        {
            return false;
        }

        if (cancelButton is null)
        {
            return false;
        }

        return true;
    }
}