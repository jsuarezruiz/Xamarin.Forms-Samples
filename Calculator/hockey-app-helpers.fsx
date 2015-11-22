module HockeyAppHelper

open Fake
open Fake.XamarinHelper
open System
open System.IO

type HockeyAppParams = {
    /// (Required) API token from https://rink.hockeyapp.net/manage/auth_tokens
    ApiToken: string
    File: string
    BuildCounter: string
}

// http://support.hockeyapp.net/kb/api/api-apps#upload-app
let private getCurlArgs token file buildCounter = seq {
    yield "-F status=2" 
    yield "-F notify=0" 
    yield sprintf "-F \"notes=Build # %s\"" buildCounter
    yield "-F notes_type=0" 
    yield sprintf "-F ipa=@%s" file
    yield sprintf "-H X-HockeyAppToken:%s" token
    yield "https://rink.hockeyapp.net/api/2/apps/upload"
}

let Upload token file buildCounter  =
    let args = getCurlArgs token file buildCounter |> String.concat " "
    printfn "HockeyApp args are %s" args
    let result = Shell.Exec ("curl", args)
    if result <> 0 then
        failwithf "curl exited with error (%d)" result