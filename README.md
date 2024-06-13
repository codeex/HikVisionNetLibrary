# HikVisionNetLibrary

在工控领域，很多时候需要访问和控制海康相机，通过程序控制海康相机可以实现变倍变焦，拍照，抓取视频等不同的操作。海康的SDK是C++编写的Dll，因为没有很好的进行包装，使用起来还是比较麻烦的，并且随着海康SDK的版本不同，各类版本有许多差异性，不好的封装会导致有很多的问题，这里把踩过的坑列举下，以便后来者少踩坑。
这里自己提供下封装的类库,支持x86和x64自动切换，目前的类库运行时是 .net framework 4.6为基础，
`后续会提供.net core 系列的类库，以支持linux跨平台操作。`

# 海康SDK下载
最新版可以到 [https://open.hikvision.com/download/5cda567cf47ae80dd41a54b3?type=10](https://open.hikvision.com/download/5cda567cf47ae80dd41a54b3?type=10) 进行下载
