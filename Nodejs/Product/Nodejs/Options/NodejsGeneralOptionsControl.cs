﻿/* ****************************************************************************
 *
 * Copyright (c) Microsoft Corporation. 
 *
 * This source code is subject to terms and conditions of the Apache License, Version 2.0. A 
 * copy of the license can be found in the License.html file at the root of this distribution. If 
 * you cannot locate the Apache License, Version 2.0, please send an email to 
 * vspython@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
 * by the terms of the Apache License, Version 2.0.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * ***************************************************************************/

using System;
using System.Windows.Forms;

namespace Microsoft.NodejsTools.Options {
    public partial class NodejsGeneralOptionsControl : UserControl {
        private const int SurveyNewsNeverIndex = 0;
        private const int SurveyNewsOnceDayIndex = 1;
        private const int SurveyNewsOnceWeekIndex = 2;
        private const int SurveyNewsOnceMonthIndex = 3;

        public NodejsGeneralOptionsControl() {
            InitializeComponent();
        }

        internal SurveyNewsPolicy SurveyNewsCheckCombo {
            get {
                switch (_surveyNewsCheckCombo.SelectedIndex) {
                    case SurveyNewsNeverIndex:
                        return SurveyNewsPolicy.Disabled;
                    case SurveyNewsOnceDayIndex:
                        return SurveyNewsPolicy.CheckOnceDay;
                    case SurveyNewsOnceWeekIndex:
                        return SurveyNewsPolicy.CheckOnceWeek;
                    case SurveyNewsOnceMonthIndex:
                        return SurveyNewsPolicy.CheckOnceMonth;
                    default:
                        return SurveyNewsPolicy.Disabled;
                }
            }
            set {
                switch (value) {
                    case SurveyNewsPolicy.Disabled:
                        _surveyNewsCheckCombo.SelectedIndex = SurveyNewsNeverIndex;
                        break;
                    case SurveyNewsPolicy.CheckOnceDay:
                        _surveyNewsCheckCombo.SelectedIndex = SurveyNewsOnceDayIndex;
                        break;
                    case SurveyNewsPolicy.CheckOnceWeek:
                        _surveyNewsCheckCombo.SelectedIndex = SurveyNewsOnceWeekIndex;
                        break;
                    case SurveyNewsPolicy.CheckOnceMonth:
                        _surveyNewsCheckCombo.SelectedIndex = SurveyNewsOnceMonthIndex;
                        break;
                }
            }
        }

        internal void SyncControlWithPageSettings(NodejsGeneralOptionsPage page) {
            _showOutputWhenRunningNpm.Checked = page.ShowOutputWindowWhenExecutingNpm;
            SurveyNewsCheckCombo = page.SurveyNewsCheck;
            _waitOnAbnormalExit.Checked = page.WaitOnAbnormalExit;
            _waitOnNormalExit.Checked = page.WaitOnNormalExit;
            _editAndContinue.Checked = page.EditAndContinue;
            _checkForLongPaths.Checked = page.CheckForLongPaths;
        }

        internal void SyncPageWithControlSettings(NodejsGeneralOptionsPage page) {
            page.ShowOutputWindowWhenExecutingNpm = _showOutputWhenRunningNpm.Checked;
            page.SurveyNewsCheck = SurveyNewsCheckCombo;
            page.WaitOnAbnormalExit = _waitOnAbnormalExit.Checked;
            page.WaitOnNormalExit = _waitOnNormalExit.Checked;
            page.EditAndContinue = _editAndContinue.Checked;
            page.CheckForLongPaths = _checkForLongPaths.Checked;
        }
    }
}