import React, { FunctionComponent } from 'react';
import GridListComponent from '../GridListComponent/GridListComponent';
import { IterableList } from '@/types';
import { Flex } from 'antd';
import HeaderComponent from '../HeaderComponent/HeaderComponent';
import CarouselComponent from '../CarouselComponent/CarouselComponent';

const HomeComponent: FunctionComponent<{_sets: IterableList[]}> = ({_sets}) => {
    return (
        <div>
            <HeaderComponent />
            <Flex justify='center' className='mt-4'>
                <div className='wrapper'>
                    <CarouselComponent />
                    <GridListComponent classNames={['mt-4']} _list={_sets} />
                </div>
            </Flex>
        </div>
    );
};

export default HomeComponent;