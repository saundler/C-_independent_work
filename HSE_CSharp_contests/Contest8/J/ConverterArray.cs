using System;
using System.Collections;

internal class ConverterArray<TV, TU> : IEnumerable
    where TV : MessageNetwork
    where TU : MessageDb
{
    public TV[] arr = new TV[0];
    public TU[] arr2;
    IConverter<TV,TU> _converter;
    public ConverterArray(int n, IConverter<TV,TU> converter)
    {
        arr = new TV[n];
        this._converter = converter;
        arr2 = new TU[n];
    }

    public IEnumerator GetEnumerator() => arr2.GetEnumerator();
    public TU GetAt(int index)
    {
        arr2[index] = _converter.Convert(arr[index]);
        return arr2[index];
    }
    
    public void SetAt(int index, TV a) => arr[index] = a;
}