import HeaderComponent from "@/components/HeaderComponent/HeaderComponent";
import InputComponent from "@/components/InputComponent/InputComponent";
import { Flex } from "antd";
import Image from "next/image";
import React from "react";

const index = () => {
  return (
    <>
      <HeaderComponent />
      <Flex justify='center' className="bg-[url('/Pokemon.webp')] lg:bg-none bg-no-repeat bg-cover">
        <Flex
            justify="space-between"
            align="center"
            className='lg:wrapper px-0 lg:px-2 w-full h-[calc(100vh-60px)]'
        >
            <Flex gap={100} justify="center" align="center" vertical className='w-full lg:w-2/4 h-full lg:h-[calc(100%-20px)] backdrop-blur-sm'>
                <p className='text-2xl text-center uppercase text-white font-semibold lg:text-black'>Welcome to the world of <br /><span className='text-2xl'>Pokemon</span></p>
                <InputComponent classNames={["bg-gray-100"]} />
            </Flex>

            <div className='bg-gray-500 rounded-[2%] overflow-hidden w-2/4 h-[calc(100%-20px)] relative hidden lg:block'>
                <Image src="/Pokemon.webp" alt="pokemon banner" objectFit="cover" fill />
            </div>
        </Flex>
      </Flex>
    </>
  );
};

export default index;
