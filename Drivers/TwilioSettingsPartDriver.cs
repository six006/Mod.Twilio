﻿using System;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Mod.Twilio.Models;
using Orchard.ContentManagement.Handlers;

// This code was generated by Orchardizer

namespace Mod.Twilio.Drivers {
    public class TwilioSettingsPartDriver : ContentPartDriver<TwilioSettingsPart> {
        protected override string Prefix {
            get { return "TwilioSettingsPart"; }
        }


        protected override DriverResult Editor(TwilioSettingsPart part, dynamic shapeHelper) {
            return ContentShape("Parts_TwilioSettingsPart_Edit",
                () => shapeHelper.EditorTemplate(
                    TemplateName: "Parts/TwilioSettingsPart",
                    Model: part,
                    Prefix: Prefix))
                    .OnGroup("SMS");
        }

        protected override DriverResult Editor(TwilioSettingsPart part, IUpdateModel updater, dynamic shapeHelper) {
            return ContentShape("Parts_TwilioSettingsPart_Edit", () => {
                var previousAuthToken = part.AuthToken;
                updater.TryUpdateModel(part, Prefix, null, null);

                // restore password if the input is empty, meaning it has not been reseted
                if (string.IsNullOrEmpty(part.AuthToken)) {
                    part.AuthToken = previousAuthToken;
                }
                return shapeHelper.EditorTemplate(TemplateName: "Parts/TwilioSettingsPart", Model: part, Prefix: Prefix);
            }).OnGroup("SMS");
        }

        protected override void Importing(TwilioSettingsPart part, ImportContentContext context) {
            var partName = part.PartDefinition.Name;
            var _AccountSID = context.Attribute(partName, "AccountSID");
            if (_AccountSID != null) {
                part.AccountSID = _AccountSID;
            }
            var _AuthToken = context.Attribute(partName, "AuthToken");
            if (_AuthToken != null) {
                part.AuthToken = _AuthToken;
            }

            var _FromNumber = context.Attribute(partName, "FromNumber");
            if (_FromNumber != null) {
                part.FromNumber = _FromNumber;
            }
        }

        protected override void Exporting(TwilioSettingsPart part, ExportContentContext context) {
            context.Element(part.PartDefinition.Name).SetAttributeValue("AccountSID", part.AccountSID);
            context.Element(part.PartDefinition.Name).SetAttributeValue("AuthToken", part.AuthToken);
            context.Element(part.PartDefinition.Name).SetAttributeValue("FromNumber", part.FromNumber);
        }
    }
}