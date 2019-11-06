import { bindActionCreators } from "redux";
import { connect } from "react-redux";
import * as Actions from "../../actions/index";
import React from "react";
import Steps from "../../components/Steps";

class Citizen extends React.Component {
  componentDidMount() {
    const { citizenId } = this.props.match.params;
    citizenId && this.props.loadCitizenById(citizenId);
  }

  render() {
    return <Steps />;
  }
}

const mapStateToProps = state => ({
  pages: state.pages
});

const mapDispatchToProps = dispatch => bindActionCreators(Actions, dispatch);

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(Citizen);
