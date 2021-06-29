
#Run this script in same level your local class repo and the .net guide is located (cloned from git?)
# Update your class code
$repoSource = "code-401-dotnet-guide/Curriculum/"
$classCode = "seattle-dotnet-401d11/"
$folder = "";


for($num = 1 ; $num -le 45; $num++)
{
	if(($num -lt 20) -or ($num -gt 25) )
	{
		if($num -lt 10){
			$folder = "Class0" + $num;
			} else{
			$folder = "Class" + $num;
		}

	$fullpath = join-path -path $classCode -childpath $folder
	$classPAth = join-path -path $repoSource -childpath $folder

		New-Item -Path $fullpath -ItemType Directory
		copy-item $classpath/README.md $fullpath

		if($num -eq 4)
		{
			New-Item -Path (join-path -path $classCode -childpath $folder/lab/"StarterCode") -ItemType Directory

			Copy-Item (join-path -path $repoSource -childpath $folder/lab/StarterCode) -Recurse $fullpath/lab

		}
	}

}

	#Class resources
	New-Item -Path (join-path -path $classCode -childpath "Class_Resources") -ItemType Directory

	# Readme Templates
	Copy-Item "code-401-dotnet-guide/resources/ReadMe_Templates" -Recurse $classCode/"Class_Resources"

	## Types file
	copy-item $repoSource/Class01/facilitator/resources/Types.md $classCode/"Class_Resources"

	#project req
	copy-item "code-401-dotnet-guide/Projects/Midterm/ProjReqs.md" $classCode/"Class_Resources"

	#Git ignore
	copy-item "code-401-dotnet-guide/.gitignore" $classCode
