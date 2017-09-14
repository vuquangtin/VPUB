namespace CommonControls
{
    /// <summary>
    /// Action that need be done after dialog closed
    /// </summary>
    public enum DialogPostAction
    {
        NONE,           // Do nothing
        NEXT,           // Continue to next step
        BACK,           // Back to previous step
        CANCEL,         // Cancel operation
        CONFIRMED,      // Confirm operation
        SUCCESS,        // Operation has been completed successfully
    }
}
