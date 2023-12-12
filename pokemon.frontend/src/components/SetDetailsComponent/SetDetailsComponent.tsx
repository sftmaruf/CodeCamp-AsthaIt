import { ISet } from '@/types';
import { Flex } from 'antd';
import Image from 'next/image';
import React, { FunctionComponent } from 'react';

const SetDetails:FunctionComponent<{_data: ISet}> = ({_data}) => {
    return (
      <Flex align="center" justify="space-between" className="backdrop-blur">
        <div>
          <p>Total: {_data?.total}</p>
          <p>Total: {_data?.printedTotal}</p>
          <p>Series: {_data?.series}</p>
          <p>Release Date: {_data?.releaseDate}</p>
          <p>Last update: {_data?.updatedAt}</p>
        </div>
        <Flex justify="space-between" gap={10}>
          <Flex
            align="center"
            className="shadow-md p-2 relative w-[100px] h-[100px]">
            <Image
              src={_data?.images.logo!}
              alt={`${_data?.name} image`}
              className="object-contain"
              sizes="100px"
              fill
            />
          </Flex>
          <Flex
            align="center"
            className="shadow-md p-2 relative w-[100px] h-[100px]">
            <Image
              src={_data?.images.symbol!}
              alt={`${_data?.name} image`}
              className="object-contain"
              sizes="100px"
              fill
            />
          </Flex>
        </Flex>
      </Flex>
    );
};

export default SetDetails;