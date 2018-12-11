﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/EditPage.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Pages_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="main-container">
        <div class="padding-md">
            <div class="panel-heading">
                <div class="row">
                    <div class="pull-right">
                        <asp:LinkButton ID="linkButtonAdd" CssClass="btn btn-sm btn-primary small" runat="server"><i class="fa fa-plus"></i> Thêm mới</asp:LinkButton>
                    </div>
                    <div class="col-md-4 col-sm-4">
                        <h4>
                            Danh sách xe
                        </h4>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    Form Element
					
                    <span class="pull-right">
                        <label class="label-checkbox inline">
                            <input type="checkbox" id="toggleLine" checked>
                            <span class="custom-checkbox"></span>
                            Toggle Line
						
                        </label>
                    </span>
                </div>
                <div class="panel-body">
                    <div id="formToggleLine" class="form-horizontal no-margin form-border">
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Help Text</label>
                            <div class="col-lg-10">
                                <input class="form-control" type="text" placeholder="input here...">
                                <span class="help-block">A block of help text that breaks onto a new line and may extend beyond one line.</span>
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Disabled</label>
                            <div class="col-lg-10">
                                <input class="form-control" type="text" placeholder="Disabled input here..." disabled>
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Password</label>
                            <div class="col-lg-10">
                                <input class="form-control" type="password" placeholder="Password">
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Static Control</label>
                            <div class="col-lg-10">
                                <p class="form-control-static">email@example.com</p>
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Textarea</label>
                            <div class="col-lg-10">
                                <textarea class="form-control" rows="3"></textarea>
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Stacked Checkbox</label>
                            <div class="col-lg-10">
                                <label class="label-checkbox">
                                    <input type="checkbox">
                                    <span class="custom-checkbox"></span>
                                    Option one is this and that be sure to include why it's great
								
                                </label>
                                <label class="label-checkbox">
                                    <input type="checkbox">
                                    <span class="custom-checkbox"></span>
                                    Option two can be something else and selecting it will deselect option one		
								
                                </label>
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Inline Checkbox</label>
                            <div class="col-lg-10">
                                <label class="label-checkbox inline">
                                    <input type="checkbox">
                                    <span class="custom-checkbox"></span>
                                    Checkbox1
								
                                </label>
                                <label class="label-checkbox inline">
                                    <input type="checkbox">
                                    <span class="custom-checkbox"></span>
                                    Checkbox2
								
                                </label>
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Stacked Radio Button</label>
                            <div class="col-lg-10">
                                <label class="label-radio">
                                    <input type="radio" name="stack-radio">
                                    <span class="custom-radio"></span>
                                    Option one is this and that be sure to include why it's great
								
                                </label>
                                <label class="label-checkbox">
                                    <input type="radio" name="stack-radio">
                                    <span class="custom-radio"></span>
                                    Option two can be something else and selecting it will deselect option one		
								
                                </label>
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Inline Radio Button</label>
                            <div class="col-lg-10">
                                <label class="label-radio inline">
                                    <input type="radio" name="inline-radio">
                                    <span class="custom-radio"></span>
                                    Option1
								
                                </label>
                                <label class="label-radio inline">
                                    <input type="radio" name="inline-radio">
                                    <span class="custom-radio"></span>
                                    Option2
								
                                </label>
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                        <div class="form-group has-success">
                            <label class="col-lg-2 control-label">Input with success</label>
                            <div class="col-lg-10">
                                <input class="form-control" type="text">
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                        <div class="form-group has-warning">
                            <label class="col-lg-2 control-label">Input with success</label>
                            <div class="col-lg-10">
                                <input class="form-control" type="text">
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                        <div class="form-group has-error">
                            <label class="col-lg-2 control-label">Input with error</label>
                            <div class="col-lg-10">
                                <input class="form-control" type="text">
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Select</label>
                            <div class="col-lg-10">
                                <select class="form-control">
                                    <option>1</option>
                                    <option>2</option>
                                    <option>3</option>
                                    <option>4</option>
                                    <option>5</option>
                                </select>
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Chosen Select</label>
                            <div class="col-lg-10">
                                <select class="form-control chzn-select">
                                    <option>Alabama</option>
                                    <option>Alaska</option>
                                    <option>Arizona</option>
                                    <option>Arkansas</option>
                                    <option>California</option>
                                    <option>Colorado</option>
                                    <option>Connecticut</option>
                                    <option>Delaware</option>
                                    <option>District Of Columbia</option>
                                    <option>Florida</option>
                                    <option>Georgia</option>
                                    <option>Hawaii</option>
                                    <option>Idaho</option>
                                    <option>Illinois</option>
                                    <option>Indiana</option>
                                    <option>Iowa</option>
                                    <option>Kansas</option>
                                    <option>Kentucky</option>
                                    <option>Louisiana</option>
                                    <option>Maine</option>
                                    <option>Maryland</option>
                                    <option>Massachusetts</option>
                                    <option>Michigan</option>
                                    <option>Minnesota</option>
                                    <option>Mississippi</option>
                                    <option>Missouri</option>
                                    <option>Montana</option>
                                    <option>Nebraska</option>
                                    <option>Nevada</option>
                                    <option>New Hampshire</option>
                                    <option>New Jersey</option>
                                    <option>New Mexico</option>
                                    <option>New York</option>
                                    <option>North Carolina</option>
                                    <option>North Dakota</option>
                                    <option>Ohio</option>
                                    <option>Oklahoma</option>
                                    <option>Oregon</option>
                                    <option>Pennsylvania</option>
                                    <option>Rhode Island</option>
                                    <option>South Carolina</option>
                                    <option>South Dakota</option>
                                    <option>Tennessee</option>
                                    <option>Texas</option>
                                    <option>Utah</option>
                                    <option>Vermont</option>
                                    <option>Virginia</option>
                                    <option>Washington</option>
                                    <option>West Virginia</option>
                                    <option>Wisconsin</option>
                                    <option>Wyoming</option>
                                </select>
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Multiple Select</label>
                            <div class="col-lg-10">
                                <select multiple class="form-control">
                                    <option>1</option>
                                    <option>2</option>
                                    <option>3</option>
                                    <option>4</option>
                                    <option>5</option>
                                </select>
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Chosen Multiple Select</label>
                            <div class="col-lg-10">
                                <select multiple class="form-control chzn-select">
                                    <option>Alabama</option>
                                    <option>Alaska</option>
                                    <option>Arizona</option>
                                    <option>Arkansas</option>
                                    <option>California</option>
                                    <option>Colorado</option>
                                    <option>Connecticut</option>
                                    <option>Delaware</option>
                                    <option>District Of Columbia</option>
                                    <option>Florida</option>
                                    <option>Georgia</option>
                                    <option>Hawaii</option>
                                    <option>Idaho</option>
                                    <option>Illinois</option>
                                    <option>Indiana</option>
                                    <option>Iowa</option>
                                    <option>Kansas</option>
                                    <option>Kentucky</option>
                                    <option>Louisiana</option>
                                    <option>Maine</option>
                                    <option>Maryland</option>
                                    <option>Massachusetts</option>
                                    <option>Michigan</option>
                                    <option>Minnesota</option>
                                    <option>Mississippi</option>
                                    <option>Missouri</option>
                                    <option>Montana</option>
                                    <option>Nebraska</option>
                                    <option>Nevada</option>
                                    <option>New Hampshire</option>
                                    <option>New Jersey</option>
                                    <option>New Mexico</option>
                                    <option>New York</option>
                                    <option>North Carolina</option>
                                    <option>North Dakota</option>
                                    <option>Ohio</option>
                                    <option>Oklahoma</option>
                                    <option>Oregon</option>
                                    <option>Pennsylvania</option>
                                    <option>Rhode Island</option>
                                    <option>South Carolina</option>
                                    <option>South Dakota</option>
                                    <option>Tennessee</option>
                                    <option>Texas</option>
                                    <option>Utah</option>
                                    <option>Vermont</option>
                                    <option>Virginia</option>
                                    <option>Washington</option>
                                    <option>West Virginia</option>
                                    <option>Wisconsin</option>
                                    <option>Wyoming</option>
                                </select>
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Height sizing</label>
                            <div class="col-lg-10">
                                <input class="form-control input-lg" type="text" placeholder=".input-lg">
                                <div class="seperator"></div>
                                <input class="form-control" type="text" placeholder="Default input">
                                <div class="seperator"></div>
                                <input class="form-control input-sm" type="text" placeholder=".input-sm">
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Column sizing</label>
                            <div class="col-lg-10">
                                <div class="row">
                                    <div class="col-lg-2">
                                        <input type="text" class="form-control" placeholder=".col-lg-2">
                                    </div>
                                    <!-- /.col -->
                                    <div class="col-lg-3">
                                        <input type="text" class="form-control" placeholder=".col-lg-3">
                                    </div>
                                    <!-- /.col -->
                                    <div class="col-lg-4">
                                        <input type="text" class="form-control" placeholder=".col-lg-4">
                                    </div>
                                    <!-- /.col -->
                                </div>
                                <!-- /.row -->
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Input Groups</label>
                            <div class="col-lg-10">
                                <div class="input-group">
                                    <span class="input-group-addon">@</span>
                                    <input type="text" class="form-control" placeholder="Username">
                                </div>
                                <!-- /input-group -->
                                <div class="seperator"></div>
                                <div class="input-group">
                                    <input type="text" class="form-control">
                                    <span class="input-group-addon">.00</span>
                                </div>
                                <!-- /input-group -->
                                <div class="seperator"></div>
                                <div class="input-group">
                                    <span class="input-group-addon">$</span>
                                    <input type="text" class="form-control">
                                    <span class="input-group-addon">.00</span>
                                </div>
                                <!-- /input-group -->
                                <div class="seperator"></div>
                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <label class="label-checkbox no-padding">
                                            <input type="checkbox">
                                            <span class="custom-checkbox"></span>
                                        </label>
                                    </span>
                                    <input type="text" class="form-control">
                                </div>
                                <!-- /input-group -->
                                <div class="seperator"></div>
                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <label class="label-radio no-padding">
                                            <input type="radio">
                                            <span class="custom-radio"></span>
                                        </label>
                                    </span>
                                    <input type="text" class="form-control">
                                </div>
                                <!-- /input-group -->
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Button addons</label>
                            <div class="col-lg-10">
                                <div class="input-group">
                                    <span class="input-group-btn">
                                        <button class="btn btn-default" type="button">Go!</button>
                                    </span>
                                    <input type="text" class="form-control">
                                </div>
                                <!-- /input-group -->
                                <div class="seperator"></div>
                                <div class="input-group">
                                    <input type="text" class="form-control">
                                    <span class="input-group-btn">
                                        <button class="btn btn-default" type="button">Go!</button>
                                    </span>
                                </div>
                                <!-- /input-group -->
                                <div class="seperator"></div>
                                <div class="input-group">
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">Action <span class="caret"></span></button>
                                        <ul class="dropdown-menu">
                                            <li><a href="#">Action</a></li>
                                            <li><a href="#">Another action</a></li>
                                            <li><a href="#">Something else here</a></li>
                                            <li class="divider"></li>
                                            <li><a href="#">Separated link</a></li>
                                        </ul>
                                    </div>
                                    <!-- /btn-group -->
                                    <input type="text" class="form-control">
                                </div>
                                <!-- /input-group -->
                                <div class="seperator"></div>
                                <div class="input-group">
                                    <input type="text" class="form-control">
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">Action <span class="caret"></span></button>
                                        <ul class="dropdown-menu pull-right">
                                            <li><a href="#">Action</a></li>
                                            <li><a href="#">Another action</a></li>
                                            <li><a href="#">Something else here</a></li>
                                            <li class="divider"></li>
                                            <li><a href="#">Separated link</a></li>
                                        </ul>
                                    </div>
                                    <!-- /btn-group -->
                                </div>
                                <!-- /input-group -->
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Segmented buttons</label>
                            <div class="col-lg-10">
                                <div class="input-group">
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-default" tabindex="-1">Action</button>
                                        <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" tabindex="-1">
                                            <span class="caret"></span>
                                        </button>
                                        <ul class="dropdown-menu" role="menu">
                                            <li><a href="#">Action</a></li>
                                            <li><a href="#">Another action</a></li>
                                            <li><a href="#">Something else here</a></li>
                                            <li class="divider"></li>
                                            <li><a href="#">Separated link</a></li>
                                        </ul>
                                    </div>
                                    <input type="text" class="form-control">
                                </div>
                                <!-- /input-group -->
                                <div class="seperator"></div>
                                <div class="input-group">
                                    <input type="text" class="form-control">
                                    <div class="input-group-btn">
                                        <button type="button" class="btn btn-default" tabindex="-1">Action</button>
                                        <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown" tabindex="-1">
                                            <span class="caret"></span>
                                        </button>
                                        <ul class="dropdown-menu pull-right" role="menu">
                                            <li><a href="#">Action</a></li>
                                            <li><a href="#">Another action</a></li>
                                            <li><a href="#">Something else here</a></li>
                                            <li class="divider"></li>
                                            <li><a href="#">Separated link</a></li>
                                        </ul>
                                    </div>
                                </div>
                                <!-- /input-group -->
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Tags</label>
                            <div class="col-lg-10">
                                <input type="text" class="tag-demo1" value="foo,bar,baz">
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                        <div class="form-group">
                            <label class="col-lg-2 control-label">WYSIHTML5</label>
                            <div class="col-lg-10">
                                <textarea id="wysihtml5-textarea" placeholder="Enter your text ..." class="form-control" rows="6"></textarea>
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Date Picker</label>
                            <div class="col-lg-10">
                                <div class="input-group">
                                    <input type="text" value="06/10/2013" class="datepicker form-control">
                                    <span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                </div>
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Time Picker</label>
                            <div class="col-lg-10">
                                <div class="input-group bootstrap-timepicker">
                                    <input class="timepicker form-control" type="text" />
                                    <span class="input-group-addon"><i class="fa fa-clock-o"></i></span>
                                </div>
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Slider</label>
                            <div class="col-lg-10">
                                <input type="text" class="form-control" value="4" id="sl1" data-slider-handle="round">
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Range Slider</label>
                            <div class="col-lg-10">
                                <input type="text" class="form-control" value="" data-slider-min="10" data-slider-max="1000" data-slider-step="5" data-slider-value="[150,650]" id="sl2">
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Vertical Slider</label>
                            <div class="col-lg-10">
                                <input type="text" class="form-control" id="sl3" data-slider-value="-13" data-slider-min="-20" data-slider-max="20" data-slider-handle="round" data-slider-orientation="vertical">
                                <input type="text" class="form-control" id="sl4" data-slider-value="-3" data-slider-min="-20" data-slider-max="20" data-slider-handle="round" data-slider-orientation="vertical">
                                <input type="text" class="form-control" id="sl5" data-slider-value="16" data-slider-min="-20" data-slider-max="20" data-slider-handle="round" data-slider-orientation="vertical">
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Form in modal</label>
                            <div class="col-lg-10">
                                <a href="#formModal" class="btn btn-success" data-toggle="modal">Form In Modal</a>
                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /form-group -->
                    </div>
                </div>
            </div>
            <!-- /panel -->
            <!-- /panel -->
            <!-- /panel -->
            <!-- /panel -->
        </div>
        <!-- /.padding-md -->
    </div>
    <!-- /main-container -->

    <!-- /Modal -->
    <div class="modal fade" id="formModal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4>Modal with form</h4>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="form-group">
                            <label>Username</label>
                            <input type="text" class="form-control input-sm" placeholder="Email Address">
                        </div>
                        <div class="form-group">
                            <label>Password</label>
                            <input type="password" class="form-control input-sm" placeholder="Password">
                        </div>
                        <div class="form-group">
                            <label class="label-checkbox">
                                <input type="checkbox" class="regular-checkbox" />
                                <span class="custom-checkbox"></span>
                                Remember me
							
                            </label>
                        </div>
                        <div class="form-group text-right">
                            <a href="#" class="btn btn-success">Sign in</a>
                            <a href="#" class="btn btn-success">Sign up</a>
                        </div>
                    </form>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    <!-- /.modal -->
    </div><!-- /wrapper -->

    <a href="" id="scroll-to-top" class="hidden-print"><i class="fa fa-chevron-up"></i></a>

    <!-- Logout confirmation -->
    <div class="custom-popup width-100" id="logoutConfirm">
        <div class="padding-md">
            <h4 class="m-top-none">Do you want to logout?</h4>
        </div>

        <div class="text-center">
            <a class="btn btn-success m-right-sm" href="login.html">Logout</a>
            <a class="btn btn-danger logoutConfirm_close">Cancel</a>
        </div>
    </div>
</asp:Content>

