open System.IO
open System.Text.RegularExpressions

let regex = Regex(@"\d")

let getScore (str : string)  =
   let matches = regex.Matches(str)
   match matches.Count with
        | 0 -> 0
        | 1 -> (matches[0].Value |> int) * 11
        | _ -> (matches[0].Value |> int) * 10 + (matches[matches.Count-1].Value |> int)

let sum =  File.ReadLines(Path.Combine (__SOURCE_DIRECTORY__, "input001.txt" ))
        |> Seq.fold (fun state (item : string) -> state + getScore item) 0

printfn $"Sum: {sum}"