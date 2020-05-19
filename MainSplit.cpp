#include<iostream>
#include <Windows.h>

using namespace std;


void main()
{
	int threshold=200;
	FILE* stream=fopen("*.200.bmp","rb");
	if(stream==NULL)
	{
		cout<<"No file"<<endl;
		return;
	}
	
	int sizeFileHeader=sizeof(BITMAPFILEHEADER);
	int sizeInfoHeader=sizeof(BITMAPINFOHEADER);
	
	BITMAPFILEHEADER* bitmapFileHeader=new BITMAPFILEHEADER[sizeFileHeader+1];
	
	BITMAPINFOHEADER* bitmapInfoHeader=new BITMAPINFOHEADER[sizeInfoHeader+1];
	
	memset(bitmapFileHeader,0,sizeFileHeader+1);
	memset(bitmapInfoHeader,0,sizeInfoHeader+1);
	fread(bitmapFileHeader,sizeof(char),sizeFileHeader,stream);
	fseek(stream,sizeFileHeader,0);
	fread(bitmapInfoHeader,sizeof(char),sizeInfoHeader,stream);
	fseek(stream,sizeInfoHeader+sizeFileHeader,0);
	RGBQUAD* pRgbQuards=new RGBQUAD[256];
	for (int k=0;k<256;k++)
	{
		fread(&pRgbQuards[k],sizeof(RGBQUAD),1,stream);
	}
	
	//split
	int count=(((bitmapInfoHeader->biWidth)*8+31)/32)*4-bitmapInfoHeader->biWidth*(bitmapInfoHeader->biBitCount/8);
	BYTE* tempData=new BYTE[count+1];
	memset(tempData,0,count+1);
	fseek(stream,sizeFileHeader+sizeInfoHeader+256*sizeof(RGBQUAD),0);
	BYTE** data=new BYTE*[bitmapInfoHeader->biHeight];
	for(int i=0;i<bitmapInfoHeader->biHeight;i++)
	{
		data[i]=new BYTE[bitmapInfoHeader->biWidth];
		for (int j=0;j<bitmapInfoHeader->biWidth;j++)
		{
			fread(&data[i][j],sizeof(char),1,stream);
			if(data[i][j]>threshold)
				data[i][j]=255;
			else
				data[i][j]=0;
		}
		for (int n=0;n<count;n++)
		{
			fread(&tempData[n],sizeof(char),1,stream);
		}
	}
	
	fclose(stream);
	


	//save
	FILE* fileWrite=fopen("*.200after.bmp","a+");
	fwrite(bitmapFileHeader,sizeof(char),sizeof(BITMAPFILEHEADER),fileWrite);
	fwrite(bitmapInfoHeader,sizeof(char),sizeof(BITMAPINFOHEADER),fileWrite);
	fwrite(pRgbQuards,sizeof(RGBQUAD),256,fileWrite);

	for(int i=0;i<bitmapInfoHeader->biHeight;i++)
	{
		for(int j=0;j<bitmapInfoHeader->biWidth;j++)
		{
			fwrite(&data[i][j],sizeof(BYTE),1,fileWrite);
		}
		for(int m=0;m<count;m++)
			fwrite(&tempData[m],sizeof(char),1,fileWrite);
	}
	fclose(fileWrite);

	cout<<"success"<<endl;
}