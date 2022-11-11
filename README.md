# brainlearn_exp_merge
Tool to help merging "brainlearn-like" experience.bin file

# most common scenario
A main BrainLearn folder containing the engine and its experience.bin file.
Several folders containing an experience.bin file.
We merge them all with this script :

cd "E:\brainlearn"
copy "E:\brainlearn1\experience.bin" experience_0.bin
copy "E:\brainlearn2\experience.bin" experience_1.bin
copy "E:\brainlearn3\experience.bin" experience_2.bin
copy "E:\brainlearn4\experience.bin" experience_3.bin
E:\brainlearn\brainlearn_exp_merge.exe
E:\brainlearn\brainLearn.exe uci isready quit
E:\brainlearn\brainlearn_exp_merge.exe defrag
