import { Carousel } from "antd";
import Image from "next/image";
import React from "react";

const contentStyle: React.CSSProperties = {
    height: '160px',
    color: '#fff',
    lineHeight: '160px',
    textAlign: 'center',
    background: '#364d79',
};

const CarouselComponent = () => {
  return (
    <div>
      <Carousel effect="fade" autoplay>
        <div className='relative w-full h-[300px]'>
          <Image src='/pokemon-1.jpg' alt='pokemon-1 image' className='object-cover' fill/>
        </div>
        <div className='relative w-full h-[300px]'>
          <Image src='/pokemon-2.jpg' alt='pokemon-2 image' className='object-cover' fill/>
        </div>
        <div className='relative w-full h-[300px]'>
          <Image src='/pokemon-3.jpg' alt='pokemon-3 image' className='object-cover' fill/>
        </div>
        <div className='relative w-full h-[300px]'>
          <Image src='/pokemon-4.jpg' alt='pokemon-4 image' className='object-cover' fill/>
        </div>
      </Carousel>
    </div>
  );
};

export default CarouselComponent;
