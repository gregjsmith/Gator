properties {

    $build_path = Resolve-Path .
    $root_path = Resolve-Path ..\.
    $output_path = "$build_path\output"

    $config = "debug"

    $sln_file = "$root_path\gator.sln"
}

task default -depends debug

task debug {

    Write-Host "Build Path: " $build_path 
    Write-Host "Root Path: " $root_path 

}


task clean {

    exec{
        msbuild $sln_file /t:Clean /p:Configuration=$config
    }

    if(Test-Path $output_path)
    {
        Remove-Item -Recurse -Force $output_path
    }

    New-Item -Path $output_path -ItemType "directory"
}


task build -depends clean {

    exec{
    
        msbuild $sln_file /t:Rebuild /p:Configuration=$config
    
    }

}