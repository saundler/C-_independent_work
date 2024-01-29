using System;

internal class Download<T> : IDownload where T : IDownload
{
    public T item;
    public Download(T item)
    {
        this.item = item;
    }
    public bool DownloadContent()
    {
        return item.DownloadContent();
    }
}

