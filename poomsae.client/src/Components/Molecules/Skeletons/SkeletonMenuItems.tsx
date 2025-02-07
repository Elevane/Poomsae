import { MenuProps, Skeleton } from "antd";
import { ItemType } from "antd/es/menu/interface";


const SkeletonMenuItems : ItemType[] = (number : number) => {
    const skeletonItems: MenuProps["items"] = new Array(4).fill(null).map((_, index) => ({
        key: `skeleton-${index}`,
        label: <Skeleton.Button active size="small" style={{ width: "80vh" }} />,
        disabled: true, // Empêche l'interaction avec le menu pendant le chargement
    }));
    return skeletonItems
}


export default SkeletonMenuItems