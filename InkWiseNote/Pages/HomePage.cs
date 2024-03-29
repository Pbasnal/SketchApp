using InkWiseNote.ViewModels;

using Systems.BackgroundJob;

using UtilsLibrary;

namespace InkWiseNote.Pages;

public class HomePage : ContentPage
{
    private HomeViewModel viewModel;
    private JobSystem jobSystem;

    private const string DIRECTORY_READER_JOB = "NOTES_PARSER_JOB";
    private const int WAIT_TIME_BEFORE_DIRECTORY_READER_JOB_STARTS_MS = 10;
    private const int WAIT_TIME_BETWEEN_DIRECTORY_READS_MS = 1000;

    public HomePage(HomeViewModel viewModel, JobSystem jobSystem)
    {
        this.viewModel = viewModel;
        this.jobSystem = jobSystem;

        ReloadNotesFromDirectory();

        jobSystem.RegisterJob(DIRECTORY_READER_JOB,
            ReloadNotesFromDirectory,
            WAIT_TIME_BEFORE_DIRECTORY_READER_JOB_STARTS_MS,
            WAIT_TIME_BETWEEN_DIRECTORY_READS_MS);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        //viewModel.Clear();
        Content = Try<View>.Executing(viewModel.GetContent)
            .HandleIfThrows(HandleContentCreationException)
            .GetResult;

        jobSystem.StartJob(DIRECTORY_READER_JOB);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        jobSystem.StopJob(DIRECTORY_READER_JOB);
    }

    private void ReloadNotesFromDirectory()
    {
        viewModel.LoadImageCardData();
    }

    private void HandleContentCreationException(Exception exception)
    {
        throw new NotImplementedException();
    }
}