# brainlearn_exp_merge
Tool to help merging "brainlearn-like" experience.bin files

# most common scenario
A folder containing the BrainLearn engine and its main experience.bin file.<br>
Several folders containing other experience.bin files.<br>
We merge them all with this script :<p>
cd "E:\brainlearn"<br>
copy "E:\brainlearn0\experience.bin" experience_0.bin<br>
copy "E:\brainlearn1\experience.bin" experience_1.bin<br>
copy "E:\brainlearn2\experience.bin" experience_2.bin<br>
copy "E:\brainlearn3\experience.bin" experience_3.bin<br>
brainlearn_exp_merge.exe<br>
brainLearn.exe uci isready quit<br>
brainlearn_exp_merge.exe defrag<br>
