import { ICard } from '@/types';
import { Button, Card, Col, Flex, Row, Typography } from 'antd';
import Image from 'next/image';
import React, { FunctionComponent } from 'react';

const AntCard3Component: FunctionComponent<{item: ICard}> = ({item}) => {
    return (
      <Card hoverable className='p-4 w-full min-h-[300px]' bodyStyle={{ padding: 0, overflow: 'hidden' }}>
        <Row>
          <Col xl={24} xxl={12} className='relative w-full h-[300px]'>
            <Image src={item.images.small} alt={`${item.name} image`} className='object-contain' fill/>
          </Col>
          <Col xl={24} xxl={12} className='flex flex-col px-0 justify-end pt-4 min-[1600px]:text-left min-[1600px]:px-4 text-center w-full'>
                <p className='sm:block text-2xl'><span className='font-thin'>{item.name} ({item.hp}<sup>hp</sup>)</span></p>
                <p className='font-bold'>Set: <span className='font-thin'>{item.set.name}</span></p>
                <p className='font-bold'>Rarity: <span className='font-thin'>{item.rarity}</span></p>
                <p className='font-bold'>Evolves From: <span className='font-thin'>{item.evolvesFrom || 'not-specified'}</span></p>
                <p className='font-bold'>Evolves To: <span className='font-thin'>{item.evolvesTo || 'not-specified'}</span></p>
                <p className='font-bold'>Artist: <span className='font-thin'>{item.artist}</span></p>
          </Col>
        </Row>
      </Card>
    );
};

export default AntCard3Component;