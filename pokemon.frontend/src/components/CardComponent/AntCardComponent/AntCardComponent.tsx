import { Card, ConfigProvider } from 'antd';
import React from 'react';
import { FunctionComponent } from 'react';
import { ISet } from '@/types';
import EditOutlined from './EditOutlined';
import Image from 'next/image';
import Link from 'next/link';

const { Meta } = Card;

const AntCardComponent: FunctionComponent<{details: ISet}> = ({details}) => {

    return (
      <ConfigProvider
        theme={{
          components: {
            Card: {
              actionsLiMargin: "0 0",
            }
          }
        }}>
        <Card
          hoverable
          style={{ width: "100%" }}
          actions={[<EditOutlined _modalInfo={details} key="details" />]}>
          <div className="relative !flex justify-center items-center w-full h-[200px] py-6">
            <Link href={`/card/${details.id}`}>
              <Image
                className="object-contain"
                alt={`${details.name} image`}
                src={details.images.logo!}
                sizes='200px'
                fill
              />
            </Link>
          </div>
          <Meta title={details.name} />
        </Card>
      </ConfigProvider>
    );
};

export default AntCardComponent;