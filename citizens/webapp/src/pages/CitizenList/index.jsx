import { bindActionCreators } from "redux";
import { connect } from "react-redux";
import * as Actions from "../../actions/index";
import React from "react";
import TableCitizens from "../../components/TableCitizens";

class CitizensList extends React.Component {
  componentDidMount() {
    this.props.cleanCitizen();
    this.props.loadCitizens();
  }

  render() {
    return <TableCitizens citizenList={this.props.pages.citizenList} />;
  }
}

const mapStateToProps = state => ({
  pages: state.pages
});

const mapDispatchToProps = dispatch => bindActionCreators(Actions, dispatch);

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(CitizensList);
