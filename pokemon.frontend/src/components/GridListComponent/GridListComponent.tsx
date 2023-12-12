import { IterableList } from '@/types';
import React, { FunctionComponent } from 'react';
import AntCardComponent from '../CardComponent/AntCardComponent/AntCardComponent';
import { Col, Row } from 'antd';

const GridListComponent: FunctionComponent<{_list: IterableList[], classNames?: string[]}> = ({_list, classNames}) => {
    return (
        <Row gutter={[16, 16]} className={classNames?.join(' ')}>
            {
                _list.map(item => {
                    return  (
                        <Col xs={12} sm={12} md={8} lg={8} key={item.id}>
                            <AntCardComponent details={item} />
                        </Col>
                    )
                })
            }
        </Row>
    );
};

export default GridListComponent;