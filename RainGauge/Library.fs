namespace RainGauge

module PDXRainGauge =

    open FSharp.Data
    open System

    type PrecipitationData = {
        StationName: string
        StationNumber: int
        _1DayAccumulation: float
        _3DayAccumulation: float
        _5DayAccumulation: float
        CurrentMonthAccumulation: float
        WaterYearAccumulation: float
        TimeOfLastReading: string
        }
        

    //declare the type
    type pdxRainProvider = HtmlProvider<"http://or.water.usgs.gov/non-usgs/bes/">

    //load the html
    let pdxRainData = pdxRainProvider.Load("http://or.water.usgs.gov/non-usgs/bes/")

 
    let pdxRainfallRecords =
        try
         let rows = 
            pdxRainData.Tables.``City of Portland HYDRA Rainfall Network 2``.Rows
              |> Array.filter (fun row -> not (row.``City of Portland Rain Gages - Station Name - Station Name``.Contains("Portland")))
              |> Array.filter (fun row -> not (row.``City of Portland Rain Gages - Station Name - Station Name``.ToLower().Contains("region")))
              |> Array.filter (fun row -> not (row.``City of Portland Rain Gages - Accumulation (inches) - 1-day``.ToLower().Contains("retired")))
              |> Array.filter (fun row -> not (row.``City of Portland Rain Gages - Station Name - Station Name``.ToLower().Contains("other")))
              |> Array.filter (fun row -> not (row.``City of Portland Rain Gages - Accumulation (inches) - Water Year``.Contains("0.0")))


         Some(seq {
            for row in rows do
            yield {
                    StationName = row.``City of Portland Rain Gages - Station Name - Station Name``
                    StationNumber = int row.``City of Portland Rain Gages - Sta. No. - Sta. No.``
                    _1DayAccumulation = float row.``City of Portland Rain Gages - Accumulation (inches) - 1-day``
                    _3DayAccumulation = float row.``City of Portland Rain Gages - Accumulation (inches) - 3-day``
                    _5DayAccumulation = float row.``City of Portland Rain Gages - Accumulation (inches) - 5-day``
                    CurrentMonthAccumulation = float row.``City of Portland Rain Gages - Accumulation (inches) - Apr``
                    WaterYearAccumulation =  float row.``City of Portland Rain Gages - Accumulation (inches) - Water Year``
                    TimeOfLastReading = row.``City of Portland Rain Gages - Time of Latest Reading - Time of Latest Reading``
                }
            })
        with 
            | :? System.FormatException -> printfn "Cast failed."; None
        
            


    
    if Option.isSome pdxRainfallRecords then
        pdxRainfallRecords.Value
        |> Seq.iter (fun row -> printfn "Station: %s \r   Number: %i \r      MTD Rainfall: %f" row.StationName row.StationNumber row.CurrentMonthAccumulation)
   
