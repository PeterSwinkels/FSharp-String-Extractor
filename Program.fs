//This module's imports and settings.
open System.IO

//This function is executed when this program is started.
[<EntryPoint>]
let main argv = 
   try      
      let rec CollectFragments characters fragments = 
         if characters = [] then
            fragments
         else
            CollectFragments characters.Tail (fragments +                                          
                                          if characters.Head >= ' ' && characters.Head <= '~' then characters.Head |> string
                                          else if fragments.EndsWith(0uy |> char |> string) then ""
                                          else 0uy |> char |> string)
      (CollectFragments (File.ReadAllBytes(argv.[0]) |> Array.map char |> Array.toList) "").Split(0uy |> char) |> Array.distinct |> Array.iter(fun newFragment -> printfn "%s" newFragment)
   with
      | exceptionO -> printfn("Error: \"%s\"") exceptionO.Message
   0