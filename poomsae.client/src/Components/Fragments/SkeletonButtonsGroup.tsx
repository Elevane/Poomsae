import { Skeleton } from "antd";

interface SkeletonButtonGroupProps {
    count: number;
    size: 'small' | 'default' | 'large';
    style?: React.CSSProperties;
}

const SkeletonButtonGroup: React.FC<SkeletonButtonGroupProps> = ({ count, size, style }) => {
    const buttons = Array.from({ length: count }, (_, index) => (
        <Skeleton.Button
            key={index}
            active
            size={size}
            style={style}
        />
    ));

    return <>{buttons}</>;
};

export default SkeletonButtonGroup;