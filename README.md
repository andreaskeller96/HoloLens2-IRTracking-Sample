# On-Device HoloLens 2 IR Tracking Sample

This project contains a sample scene showcasing how to track passive, retro-reflective IR sphere marker arrays using only the HoloLens 2 sensors.


## How to use
In the tracking sample scene, adjust the sphere positions under MixedRealityPlayspace->SampleTool->Sphere* so their local positions correspond to your own physical tracking array. If you have an array with a different amount of spheres, adjust the SampleTool GameObject accordingly. The default sphere radius is set as 6.5mm, if you are working with different sizes you need to adjust the number for best results. If you are working with flat markers, set the sphere radius to 0.

To run this on the HoloLens2, simply build and deploy. Make sure to use Release settings for the final compile in Visual Studio.

## Thanks
Special thanks to Wenhao Gu for his hololens plugin project that this dll is based on: https://github.com/petergu684/HoloLens2-ResearchMode-Unity
This project also makes use of a number of awesome open source libraries, including:
* [opencv](https://github.com/opencv/opencv)
* [libtiff](https://gitlab.com/libtiff/libtiff)
* [zlib](https://github.com/madler/zlib)


## License and Citation

If you use this project or the library contained within, please cite the following BibTeX entries:

```BibTeX
@misc{keller2023hl2irtracking,
  author =       {Andreas Keller},
  title =        {HoloLens 2 Infrared Retro-Reflector Tracking},
  howpublished = {\url{https://github.com/andreaskeller96/HoloLens2-IRTracking}},
  year =         {2023}
}
```
A. Keller, HoloLens 2 Infrared Retro-Reflector Tracking. https://github.com/andreaskeller96/HoloLens2-IRTracking, 2023. [Online]. Available: https://github.com/andreaskeller96/HoloLens2-IRTracking

```bibtex
@ARTICLE{10021890,
  author={Martin-Gomez, Alejandro and Li, Haowei and Song, Tianyu and Yang, Sheng and Wang, Guangzhi and Ding, Hui and Navab, Nassir and Zhao, Zhe and Armand, Mehran},
  journal={IEEE Transactions on Visualization and Computer Graphics}, 
  title={STTAR: Surgical Tool Tracking using Off-the-Shelf Augmented Reality Head-Mounted Displays}, 
  year={2023},
  volume={},
  number={},
  pages={1-16},
  doi={10.1109/TVCG.2023.3238309}}

```
A. Martin-Gomez et al., “STTAR: Surgical Tool Tracking using Off-the-Shelf Augmented Reality Head-Mounted Displays,” IEEE Transactions on Visualization and Computer Graphics, pp. 1–16, 2023, doi: 10.1109/TVCG.2023.3238309.
