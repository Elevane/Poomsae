import { Menu, MenuProps } from "antd";
import { Header } from "antd/es/layout/layout";
import Title from "antd/es/typography/Title";
import { useEffect, useState } from "react";
import { Link, useLocation, useNavigate } from "react-router";
import Logo from "../Atoms/Logo";
const HeaderFragment: React.FC = () => {
	const navigate = useNavigate();
	const location = useLocation();
	const [pageIndex, setPageIndex] = useState<string>("");
	const pages = ['hub', 'learn', 'account'];

	const menuItems: MenuProps['items'] = pages.map((name, key) => ({
		key: String(key),
		label: name.charAt(0).toUpperCase() + name.slice(1),
		onClick: () => navigate(`/${name}`)
	}));

	useEffect(() => {
		const page = location.pathname.split("/")[1];
		const newPageIndex = pages.findIndex(p => p === page);
		if (`${newPageIndex}` !== pageIndex) {
			setPageIndex(`${newPageIndex}`);
		}
	}, [location.pathname, pageIndex]);


	return (
		<Header style={{ display: 'flex', alignItems: 'center', justifyContent: "space-between" }}>

			<Logo name="header_logo_white" size="big" style={{ filter: "invert(1)" }} />
			<Title level={1} style={{ fontFamily: "Nunito, serif", color: "White", display: "flex", alignItems: "center" }}>Poomsae </Title>
			<Menu
				theme="dark"
				mode="horizontal"
				selectedKeys={[pageIndex ?? "0"]}
				items={menuItems}
				style={{ flex: 1, display: 'flex', alignItems: 'center', justifyContent: "flex-start", marginLeft: "5vh" }}
			/>

			<Link to="/logout" >Disconnect</Link>
		</Header>
	);
}

export default HeaderFragment;
