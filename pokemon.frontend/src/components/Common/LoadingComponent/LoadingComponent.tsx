import { Spin } from 'antd';
import React from 'react';

const LoadingComponent = () => {
    return <Spin spinning={true} fullscreen />
}

export default LoadingComponent;