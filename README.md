# On-Device HoloLens 2 IR Tracking Sample

This project contains a sample scene showcasing how to use track passive IR sphere markers using only the HoloLens 2 sensors.


## How to use
In the tracking sample scene, adjust the sphere positions under MixedRealityPlayspace->SampleTool->Sphere* so their local positions correspond to your own physical tracking array. If you have an array with a different amount of spheres, adjust the SampleTool GameObject accordingly. The default sphere radius is set as 6.5mm, if you are working with different sizes you need to adjust the number for best results. If you are working with flat markers, set the sphere radius to 0.

To run this on the HoloLens2, simply build and deploy. Make sure to use Release settings for the final compile in Visual Studio.

## Thanks
This project makes use of a number of awesome open source libraries, including:
* [opencv](https://github.com/opencv/opencv)
* [libtiff](https://gitlab.com/libtiff/libtiff)
* [zlib](https://github.com/madler/zlib)


## License and Citation

If you use this project or the library contained within in your research, please reference this repository as well as the original STTAR paper:

A. Martin-Gomez et al., "STTAR: Surgical Tool Tracking using Off-the-Shelf Augmented Reality Head-Mounted Displays," in IEEE Transactions on Visualization and Computer Graphics, doi: 10.1109/TVCG.2023.3238309.

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